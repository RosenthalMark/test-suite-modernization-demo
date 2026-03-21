import { test, expect } from '@playwright/test';
import { LoginPage } from '../pages/LoginPage';
import { HomePage } from '../pages/HomePage';

test.describe('TherapyNotes UI Tests', () => {

  test('LoginToTherapyNotes', async ({ page }) => {

    const loginPage = new LoginPage(page);
    const homePage = new HomePage(page);

    // Navigate to TherapyNotes homepage
    await loginPage.navigate();

    // Click the Log In link from the homepage
    await loginPage.clickLoginLink();

    // Enter credentials and submit
    await loginPage.login('QaInterviewPractoce', 'HorshamPA19044!!');

    // Assert login was successful
    await homePage.assertWelcomeMessage();

  });

  test.afterEach(async ({ page }) => {
    // Teardown — clear session state
    await page.context().clearCookies();
  });

});