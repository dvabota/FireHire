
using FireHire.Server.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FireHire
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<FireHireDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.MapGet("/getResumes", async (FireHireDbContext _context) =>
            {
                return Results.Ok(_context.Resumes.ToList());
            });

            app.MapPost("/uploadCVFile", async (FireHireDbContext _context, HttpRequest request) =>
            {
                var form = await request.ReadFormAsync();

                if (form.Files.ToList().Count == 0)
                    return Results.BadRequest("File not found");

                foreach (var file in form.Files)
                {
                    string data = "";

                    PdfReader reader = new PdfReader(file.OpenReadStream());
                    PdfDocument pdfDoc = new PdfDocument(reader);
                    ITextExtractionStrategy textExtraction = new SimpleTextExtractionStrategy();

                    for (int page = 1; page < pdfDoc.GetNumberOfPages(); page++)
                    {

                        data += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), textExtraction);
                    }

                    try
                    {
                        _context.Resumes.Add(new ResumeDb(0, data, file.FileName, "Not checked"));
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }

                return Results.Ok();
            });


            app.Run();
        }
    }
}