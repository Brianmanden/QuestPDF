using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(container =>
{
    container.Page(page =>
    {
        #region INIT Document
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(ts => ts.FontSize(11).FontFamily("Arial"));
        #endregion

        #region Header
        page.Header()
                .Border(1)
                .Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Cell().Column(1).Row(1).Table(innerTable =>
                    {
                        innerTable.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                        });

                        innerTable.Cell().Column(1).Row(1).AlignLeft().Element(Block).Text("Brian Juul Andersen").Bold();
                        innerTable.Cell().Column(1).Row(2).AlignLeft().Element(Block).Hyperlink("https://maps.app.goo.gl/fh9uMoTVCYrzDpnUA").Text("Hedensted");
                        innerTable.Cell().Column(1).Row(3).AlignLeft().Element(Block).Text("mail@kree8tive.dk");
                        innerTable.Cell().Column(1).Row(4).AlignLeft().Element(Block).Text("2884-7617");
                    });

                    //Element(Block).Text($"-1- \r\n -2-");
                    //table.Cell().Column(1).Row(2).Element(Block).Text("-2-");
                    //table.Cell().Column(1).Row(3).Element(Block).Text("-3-");
                    table.Cell().Column(2).Row(1).Element(Block).Image("Assets\\BrianJuulAndersen.jpg");

                });


        //page.Header().Column(column =>
        //{
        //    column.Item().ShowOnce().Background(Colors.Blue.Lighten2).Height(60);
        //    column.Item().SkipOnce().Background(Colors.Green.Lighten2).Height(40);
        //});

        #endregion

        #region Content
        page.Content();
        #endregion

        #region Footer
        page.Footer();
        #endregion
    });
})
.ShowInPreviewer();
//.GeneratePdf("TEST.pdf");

Console.ReadKey();

static IContainer Block(IContainer container)
{
    return container
        .Border(1)
        .Background(Colors.Grey.Lighten3)
        .ShowOnce()
        .MinWidth(50)
        .MinHeight(50)
        .AlignCenter()
        .AlignMiddle();
}
