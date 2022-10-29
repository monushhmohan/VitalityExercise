using Microsoft.Playwright;

public class PageObjects : BasePageObject{

    public override string PagePath => "https://www.bbc.co.uk/weather";
    private Func<string, string> WeatherByDateLocator => delegate (string date)
    {
        //convert string to int
        var tomorrowDate = int.Parse(date) + 1;
        //increment int by 1 to get tomorrow's date
        return $"(//span[contains(text(),'{tomorrowDate}')])[2]";
    };

    private string TomorrowHighTempLocator => "(//span[@class='wr-value--temperature--c'])[3]";
    private string TomorrowLowTempLocator => "(//span[@class='wr-value--temperature--c'])[4]";


    public PageObjects(IBrowser browser)
    {
        Browser = browser;
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }

    public async Task FillInSearchField(string subject)    
    {       
        await Page.FillAsync("id=ls-c-search__input-label", subject);       
    } 
    public async Task ClickOnSearchAsync(string subject)
    {        
        await Page.RunAndWaitForNavigationAsync(async () =>
        {
            await Page.ClickAsync("//input[@type='submit']");
            await Page.ClickAsync($"//span[contains(text(),'{subject}')]");
        });
        
    }
    private bool IsNextDayDispayed(string date)
    {
        return Page.Locator(WeatherByDateLocator(date)).IsVisibleAsync().Result;
    }

    public async Task<PageObjects> VerifyTempertureResultsDisplay(string date)
    {       

        IsNextDayDispayed(date).Should().BeTrue($"because following day's weather is displayed on the results page");        
        return this;
    }

    public async Task<PageObjects> VerifyHighAnLowTemperatures()
    {
        string highTemp = await Page.Locator(TomorrowHighTempLocator).InnerTextAsync();
        string lowTemp = await Page.Locator(TomorrowLowTempLocator).InnerTextAsync();
        //Trim 'degree' from temperature value(string)
        char[] charsToTrim1 = { '°' };

        int tomorrowHighTemp = int.Parse(highTemp.TrimEnd(charsToTrim1));
        int tomorrowLowTemp = int.Parse(lowTemp.TrimEnd(charsToTrim1));

        if (tomorrowHighTemp > tomorrowLowTemp)
        {
            Console.WriteLine("Tomorrow's high temperture is higher than tomorrow's lower temperature");
        }
        else
            Console.WriteLine("Tomorrow's high temperture is NOT higher than tomorrow's lower temperature");
        return this;
    }
}