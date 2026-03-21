import { test, expect } from '@playwright/test';

test.describe('TherapyNotes UI Tests', () => {

  test.describe('Login Page Smoke Tests', () => {

    test.beforeEach(async ({ page }) => {
      await page.goto('/app/login/');
    });

    test('login page has correct title', async ({ page }) => {
      await expect(page).toHaveTitle(/Log In/i);
    });

    test('login form container is present', async ({ page }) => {
      await expect(page.locator('#FormContainer')).toBeVisible();
    });

    test('login form is present', async ({ page }) => {
      await expect(page.locator('#LoginForm')).toBeVisible();
    });

    test('Practice Code label is visible', async ({ page }) => {
      await expect(page.locator('label[for="PracticeCode"]')).toBeVisible();
    });

    test('Practice Code input field is present', async ({ page }) => {
      await expect(page.locator('#PracticeCode')).toBeAttached();
    });

    test('Continue button is present', async ({ page }) => {
      await expect(page.locator('#Continue__ContinueButton')).toBeVisible();
    });

    test('Continue button text is correct', async ({ page }) => {
      await expect(page.locator('#Continue__ContinueButton')).toContainText('Continue');
    });

    test('Forgot practice code link is present', async ({ page }) => {
      await expect(page.locator('a[href="/help/login/lostpractice/"]')).toBeVisible();
    });

    test('TherapyNotes logo is present on login page', async ({ page }) => {
      await expect(page.locator('#BrandImage')).toBeVisible();
    });

    test('Practice Code field accepts input', async ({ page }) => {
      await page.locator('#PracticeCode').fill('QaInterviewPractice');
      await expect(page.locator('#PracticeCode')).toHaveValue('QaInterviewPractice');
    });

    test('valid practice code reveals credentials form', async ({ page }) => {
      await page.locator('#PracticeCode').fill('QaInterviewPractice');
      await page.locator('#Continue__ContinueButton').click();
      await expect(page.locator('#Login__UsernameField')).toBeVisible({ timeout: 10000 });
    });

    test('username field is present after practice code step', async ({ page }) => {
      await page.locator('#PracticeCode').fill('QaInterviewPractice');
      await page.locator('#Continue__ContinueButton').click();
      await expect(page.locator('#Login__UsernameField')).toBeVisible({ timeout: 10000 });
      await expect(page.locator('label[for="Login__UsernameField"]')).toBeVisible();
    });

    test('password field is present after practice code step', async ({ page }) => {
      await page.locator('#PracticeCode').fill('QaInterviewPractice');
      await page.locator('#Continue__ContinueButton').click();
      await expect(page.locator('#Login__Password')).toBeVisible({ timeout: 10000 });
      await expect(page.locator('label[for="Login__Password"]')).toBeVisible();
    });

    test('Log In button is present after practice code step', async ({ page }) => {
      await page.locator('#PracticeCode').fill('QaInterviewPractice');
      await page.locator('#Continue__ContinueButton').click();
      await expect(page.locator('#Login__LogInButton')).toBeVisible({ timeout: 10000 });
    });

    test('Forgot password link is present after practice code step', async ({ page }) => {
      await page.locator('#PracticeCode').fill('QaInterviewPractice');
      await page.locator('#Continue__ContinueButton').click();
      await expect(page.locator('a[href="/help/login/lostpassword/"]')).toBeVisible({ timeout: 10000 });
    });

  });

  test.afterEach(async ({ page }) => {
    await page.context().clearCookies();
  });

});
