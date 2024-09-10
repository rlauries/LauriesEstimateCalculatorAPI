using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using LauriesEC.Service.Calculator.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Gate.Services.Interfaces;

namespace LauriesEC.Service.Calculator
{
    
    public class Invoice: IInvoice
    {

        public IPriceByService _priceByService;

        //public decimal Total {  get; set; }

        public Invoice(IPriceByService priceByService)
        {
            _priceByService = priceByService;
            

        }
        public byte[] DownloadPdf(byte[] imageData, FenceModelFromTheBody viewFence, string stateName, int numberOfDoors)
        {

            
            var dataPdf = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(30);

                    page.Header().ShowOnce().Row(row =>
                    {
                        //var imagePath = Path.Combine(_host.WebRootPath, "images/LogoWallpapers2.jpg");
                        //byte[] imageData = System.IO.File.ReadAllBytes(imagePath);

                        row.ConstantItem(240).Image(imageData);

                    });


                    page.Content().PaddingVertical(10).Column(colContent =>
                    {
                        colContent.Item().Row(row => {
                            row.RelativeItem().BorderColor("#0b0c5c").Column(col =>
                            {


                                col.Item().Padding(10).Text("Lauries Welding Group").FontColor("#f1683a").Bold().FontSize(20);

                                col.Item().PaddingVertical(5).PaddingHorizontal(10).Text(txt =>
                                {
                                    txt.Span("Email: ").Bold().FontSize(10);
                                    txt.Span("Laurieswg@gmail.com").FontSize(10);
                                });
                                col.Item().PaddingVertical(5).PaddingHorizontal(10).Text(txt =>
                                {
                                    txt.Span("Address: ").Bold().FontSize(10);
                                    txt.Span("508 NW 43rd st, Oakland Park, 33334").FontSize(10);
                                });
                                col.Item().PaddingVertical(5).PaddingHorizontal(10).Text(txt =>
                                {
                                    txt.Span("Phone Number: ").Bold().FontSize(10);
                                    txt.Span("(786)-486-8465").FontSize(10);
                                });
                            });
                            row.RelativeItem().PaddingHorizontal(30).BorderColor("#0b0c5c").Column(col =>
                            {
                                var invoiceNumber = Placeholders.Random.Next(100, 1000);
                                col.Item().Padding(10).Text($"Invoice # {invoiceNumber}").Bold().FontColor("#f1683a").FontSize(20);
                                col.Item().PaddingVertical(5).PaddingHorizontal(10).Text(txt =>
                                {
                                    txt.Span("Company Name: ").Bold().FontSize(10);
                                    txt.Span("Barbara Anderson INC").FontSize(10);
                                });
                                col.Item().PaddingVertical(5).PaddingHorizontal(10).Text(txt =>
                                {
                                    txt.Span("Address: ").Bold().FontSize(10);
                                    txt.Span("1820 sw 120ct, Miami, Fl 33178").FontSize(10);
                                }); col.Item().PaddingVertical(5).PaddingHorizontal(10).Text(txt =>
                                {
                                    txt.Span("Phone Number: ").Bold().FontSize(10);
                                    txt.Span("(786)-786-2234").FontSize(10);
                                });
                            });
                        });

                        colContent.Item().PaddingVertical(25).LineHorizontal(0.5f);

                        decimal panelTotal = 0;
                        decimal subtotal = 0;
                        var fence = _priceByService.GetFencePaperListWithoutTax(viewFence);
                        var standardGatePrice = _priceByService.PricePerStandarGate();
                        decimal gateTotal = standardGatePrice * numberOfDoors;
                        var taxByStateName = _priceByService.TaxRateByStateName(stateName);

                        var item = fence.GetMaterialList();
                        //--------------Panel Table-------------------------------------

                        colContent.Item().Table(table => {
                            table.ColumnsDefinition(columns => {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            table.Header(header => {
                                header.Cell().Background("#0b0c5c").Padding(2).Text($"Product: {viewFence.SqFeet} Sq/Feet").FontColor(Colors.White);
                                header.Cell().Background("#0b0c5c").Padding(2).AlignCenter().Text("Quantity").FontColor(Colors.White);
                                header.Cell().Background("#0b0c5c").Padding(2).AlignCenter().Text("Price").FontColor(Colors.White);
                                header.Cell().Background("#0b0c5c").Padding(2).AlignCenter().Text("Material").FontColor(Colors.White);
                                header.Cell().Background("#0b0c5c").Padding(2).AlignRight().Text("Total").FontColor(Colors.White);


                            });

                            //------------Fill Panel the table -------------------
                            
                            
                            
                            for(int i = 0; i < item.Count; i++ )
                            {
                                var name = item[i].Name;
                                var quantity = item[i].quantityBySqFeet;
                                var price = item[i].Price;

                                table.Cell().BorderBottom(0.5f).BorderColor("#0b0c5c")
                                     .Padding(2).Text(name).FontSize(10);
                                table.Cell().BorderBottom(0.5f).BorderColor("#0b0c5c")
                                     .Padding(2).AlignCenter().Text(quantity.ToString()).FontSize(10);
                                table.Cell().BorderBottom(0.5f).BorderColor("#0b0c5c")
                                     .Padding(2).AlignCenter().Text(price.ToString()).FontSize(10);
                                table.Cell().BorderBottom(0.5f).BorderColor("#0b0c5c")
                                     .Padding(2).AlignCenter().Text("Aluminio").FontSize(10);
                                table.Cell().BorderBottom(0.5f).BorderColor("#0b0c5c")
                                     .Padding(2).AlignRight().Text($"$ {quantity * price}").FontSize(10);

                                panelTotal += quantity * price;
                            }


                        });

                        // ----------End Panel Table -------------------------------

                        //---Blank row--------------------------------
                        colContent.Item().AlignRight().Row(row => {
                            row.RelativeItem().Text("");
                        });
                        //---End of Blank row--------------------------------

                        //------------Gate Table -------------------
                        colContent.Item().Table(gateTable => {
                            gateTable.ColumnsDefinition(columns => {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            gateTable.Header(header => {
                                header.Cell().Background("#0b0c5c").Padding(2).Text("Product").FontColor(Colors.White);
                                header.Cell().Background("#0b0c5c").Padding(2).AlignCenter().Text("Quantity").FontColor(Colors.White);
                                header.Cell().Background("#0b0c5c").Padding(2).AlignCenter().Text("Price").FontColor(Colors.White);
                                header.Cell().Background("#0b0c5c").Padding(2).AlignRight().Text("Total").FontColor(Colors.White);


                            });

                            colContent.Item().AlignRight().Row(row => {
                                row.RelativeItem(2).BorderBottom(0.5f).Padding(2).Text("Gates");
                                row.RelativeItem().BorderBottom(0.5f).AlignCenter().Text(numberOfDoors.ToString());
                                row.RelativeItem().BorderBottom(0.5f).AlignCenter().Text(standardGatePrice.ToString());
                                row.RelativeItem().BorderBottom(0.5f).AlignRight().Text($"{gateTotal}");

                            });
                        });
                        //-------------end Gate Table ----------------------------------

                        //---Blank row--------------------------------
                        colContent.Item().AlignRight().Row(row => {
                            row.RelativeItem().Text("");
                        });
                        //---End of Blank row--------------------------------

                        subtotal = panelTotal + gateTotal;
                        
                        colContent.Item().AlignRight().Row(row => {
                            row.ConstantItem(150).BorderBottom(0.2f)
                               .Background("#0b0c5c").Text("Subtotal").FontSize(14).Bold().AlignCenter().FontColor(Colors.White);
                            row.ConstantItem(120).BorderBottom(0.2f).BorderTop(0.2f)
                               .Text($"$ {subtotal}").FontSize(12).AlignRight();

                        });
                        colContent.Item().AlignRight().Row(row => {
                            row.ConstantItem(150).BorderBottom(0.2f)
                               .Background("#0b0c5c").Text("Tax").FontSize(14).Bold().AlignCenter().FontColor(Colors.White);
                            row.ConstantItem(120).BorderBottom(0.2f)
                               .Text($"$ {taxByStateName}").FontSize(12).AlignRight();

                        });
                        colContent.Item().AlignRight().Row(row => {
                            row.ConstantItem(150).BorderBottom(0.2f)
                               .Background("#0b0c5c").Text("Total").FontSize(14).Bold().AlignCenter().FontColor(Colors.White);
                            row.ConstantItem(120).BorderBottom(0.2f)
                               .Text($"$ {subtotal + (subtotal * taxByStateName / 100 )}").FontSize(12).AlignRight();

                        });

                    });

                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ");
                        txt.CurrentPageNumber();
                        txt.Span(" of ");
                        txt.TotalPages();
                    });
                });
            }).GeneratePdf();

            return dataPdf;
        }

    }
}
