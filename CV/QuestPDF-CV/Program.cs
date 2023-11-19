using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(container =>
{
    container.Page(page =>
    {
        #region INIT Document
        QuestPDF.Settings.License = LicenseType.Community;
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(ts => ts.FontSize(11).FontFamily("Arial").LineHeight(1.5f));
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

                    table.Cell().Column(2).Row(1).Element(Block).Width(4.35f, Unit.Centimetre).Image("Assets\\BrianJuulAndersen.jpg");

                });
        #endregion

        #region Content
        page.Content()
            .Column(column => {
                column
                    .Item()
                    .AlignCenter()
                    .PaddingTop(50)
                    .Text("Curriculum Vitae")
                    .FontFamily("Merriweather")
                    .FontSize(30);
                column
                    .Item()
                    .PaddingVertical(5)
                    .LineHorizontal(1)
                    .LineColor("#6d9eeb");
                column
                    .Item()
                    .AlignCenter()
                    .PaddingTop(10)
                    .Text("Brian Juul Andersen")
                    .Italic(true)
                    .FontFamily("Merriweather")
                    .FontSize(17)
                    .FontColor("#6d9eeb");
                column
                    .Item()
                    .PaddingTop(10)
                    .Text("Personligt resumé")
                    .FontFamily("Trebuchet MS")
                    .FontSize(16)
                    .FontColor("#1155cc");
                column
                    .Item()
                    .PaddingTop(10)
                    .Text(text =>
                    {
                        text.Span("Brian kort fortalt: ").Bold();
                        text.Span("erfaren fullstack webudvikler, lettere nørdet, bidt af en gal computer siden Commodore 64, bredt interessefelt inden for tekniske emner. Har været med til at starte makerspacet Open Space Aarhus og deltaget i CCC og OHM. Ivrig League of Legends-spiller. Holder meget af naturen og tager ofte ud og camperer i bil, går en tur på Harrild Hede, slapper af ved et bål med en kop the eller overnatter i hængekøjen.\r\nNår tiden er til det så koder jeg på hobbyprojekter: Split View Commander og Juul Timesedler er blandt de seneste projekter.\r\n51 år, single og ingen børn.\r\n");
                        text.Span("Hvad bringer fremtiden? ").Bold();
                        text.Span("Mere webudvikling… og det selvfølgelig indenfor .NET / .NET CORE, TypeScript / JavaScript og relaterede teknologier.");
                    });
                column.Item().PaddingTop(50f).PageBreak();
                column
                    .Item()
                    .PaddingTop(10)
                    .Text("Erfaring")
                    .FontFamily("Trebuchet MS")
                    .FontSize(16)
                    .FontColor("#1155cc");
            });
        #endregion

        #region Footer
        page.Footer()
            .Text(text =>
            {
                text.Hyperlink("OSAA", "https://osaa.dk/").Underline(true).FontColor("#1155cc");
                text.Span("  -  ");
                text.Hyperlink("Chaos Computer Club", "https://www.ccc.de/en/?language=en").Underline(true).FontColor("#1155cc");
                text.Span("  -  ");
                text.Hyperlink("Observe Hack Make", "https://en.wikipedia.org/wiki/Observe._Hack._Make.").Underline(true).FontColor("#1155cc");
                text.Span("\r\n");
                text.Hyperlink("Split View Commander", "https://github.com/brianmanden/SplitViewCommander").Underline(true).FontColor("#1155cc");
                text.Span("  -  ");
                text.Hyperlink("Juul Timesedler", "https://github.com/Brianmanden/juultimesedler").Underline().FontColor("#1155cc");
                text.Span("  -  ");
                text.Hyperlink("StackShare Profil", "https://stackshare.io/BrianJuulAndersen").Underline(true).FontColor("#1155cc");
            });
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
