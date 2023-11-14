using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(container =>
{

    container.Page(page =>
    {
        //page.Size(PageSizes.A4);
        page.Size(PageSizes.A4.Landscape());
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.Yellow.Lighten5);
        page.DefaultTextStyle(ts => ts.FontSize(20)
                                        .FontColor(Colors.Orange.Lighten1)
                                        .FontFamily("Times New Roman"));

        page.Header()
                .Text("Hello World!")
                .SemiBold()
                .FontSize(28)
                .FontColor(Colors.Blue.Medium)
                .LetterSpacing(0.8f);

        page.Content()
                .PaddingVertical(2.5f, Unit.Centimetre)
                .Column(col =>
                {
                    col.Spacing(20);

                    col.Item().Text(Placeholders.LoremIpsum());
                    col.Item().Image(Placeholders.Image(200, 75));
                });

        page.Footer()
                .AlignCenter()
                .Text(t => {
                    t.Span("Page: ");
                    t.CurrentPageNumber();
                });
    });
})
.ShowInPreviewer(); 

Console.ReadKey();