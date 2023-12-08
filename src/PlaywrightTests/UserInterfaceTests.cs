// Copyright Information
// ==================================
// SoftwareTesting - PlaywrightTests - UserInterfaceTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace PlaywrightTests;

public class UserInterfaceTests
{
    //https://medium.com/version-1/playwright-a-modern-end-to-end-testing-for-web-app-with-c-language-support-c55e931273ee#:~
    [Fact]
    public static async Task VerifyTest1Creds()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using var browser =
            await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true, SlowMo = 50 });

        IBrowserContext context = await browser.NewContextAsync();

        IPage page = await context.NewPageAsync();
        // Navigate to letsusedata.com
        await page.GotoAsync("https://letsusedata.com");
        
        // Fill in the login credentials for Test1
        await page.FillAsync("#txtUser", "Test1");
        await page.FillAsync("#txtPassword", "12345678");
    
        // Click on the login button
        await page.ClickAsync("#javascriptLogin");
        
        // Verify that the user is logged in successfully, but scince we know this will fail, expect an error
        await Assertions.Expect(page.GetByText("Invalid Password")).ToBeVisibleAsync();
    }
    // Do the same test but with Test2 credentials
    [Fact]
    public static async Task VerifyTest2Creds()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using var browser =
            await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true, SlowMo = 50 });

        IBrowserContext context = await browser.NewContextAsync();

        IPage page = await context.NewPageAsync();
        // Navigate to letsusedata.com
        await page.GotoAsync("https://letsusedata.com");
        
        // Fill in the login credentials for Test1
        await page.FillAsync("#txtUser", "Test2");
        await page.FillAsync("#txtPassword", "iF3sBF7c");
    
        // Click on the login button
        var response = await page.RunAndWaitForNavigationAsync(async () => await page.ClickAsync("#javascriptLogin"));
        
        // Verify that the user is logged in successfully
        Assert.Equal("https://letsusedata.com/CourseSelection.html", page.Url);
    }
}
