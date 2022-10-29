using System.ComponentModel;

[Binding]
public class CompareTemperaturesStepDefinitions
{
    private readonly PageObjects _pageObject;
    private string today = DateTime.Today.ToString("dd");    

    public CompareTemperaturesStepDefinitions(PageObjects pageObject)
    {
        _pageObject = pageObject;      
    }

    [Given(@"the user is on BBC Weather page")]
    public async Task GivenTheUserIsOnBBCWeatherPage()
    {
        await _pageObject.NavigateAsync();
    }

    [Given(@"he types in Bournemouth into the search field")]
    public async Task GivenHeTypesInBournemouthIntoTheSearchField()
    {
        await _pageObject.FillInSearchField("Bournemouth");
    }

    [When(@"he clicks search")]
    public async Task WhenHeClicksSearch()
    {
        await _pageObject.ClickOnSearchAsync("Bournemouth");
    }

    [Then(@"he navigates to Bournemouth's weather results page")]
    public async Task ThenHeNavigatesToBournemouthWeatherResultsPage()
    {
        await _pageObject.VerifyTempertureResultsDisplay(today);        
    }

    [Then(@"he varifies high and low temperatures for the following day")]
    public async Task ThenHeVarifiesHighAndLowTemperaturesForTheFollowingDay()
    {
        await _pageObject.VerifyHighAnLowTemperatures();   
    }

}