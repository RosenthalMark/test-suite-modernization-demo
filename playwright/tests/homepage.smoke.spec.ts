import { test, expect } from '@playwright/test';

test.describe('TherapyNotes UI Tests', () => {

  test.describe('Homepage Smoke Tests', () => {

    test.beforeEach(async ({ page }) => {
      await page.goto('/');
    });

    test('homepage has correct page title', async ({ page }) => {
      await expect(page).toHaveTitle(/TherapyNotes/i);
    });

    test('main navigation is visible', async ({ page }) => {
      await expect(page.locator('#MainMenu__Header')).toBeVisible();
    });

    test('TherapyNotes logo is present', async ({ page }) => {
      await expect(page.locator('#MainMenu__Logo')).toBeVisible();
    });

    test('logo links to homepage', async ({ page }) => {
      await expect(page.locator('#MainMenu__LogoLink')).toHaveAttribute('href', '/');
    });

    test('Features nav link is visible', async ({ page }) => {
      await expect(page.locator('#MainMenu__FeaturesLink')).toBeVisible();
    });

    test('Pricing nav link is visible', async ({ page }) => {
      await expect(page.locator('#MainMenu__PricingLink')).toBeVisible();
    });

    test('Blog nav link is visible', async ({ page }) => {
      await expect(page.locator('#MainMenu__BlogLink')).toBeVisible();
    });

    test('About nav link is visible', async ({ page }) => {
      await expect(page.locator('#MainMenu__AboutLink')).toBeVisible();
    });

    test('Contact nav link is visible', async ({ page }) => {
      await expect(page.locator('#MainMenu__ContactLink')).toBeVisible();
    });

    test('Log In button is present in nav', async ({ page }) => {
      await expect(page.locator('a[href="/app/login/"]')).toBeVisible();
    });

    test('Log In button links to login page', async ({ page }) => {
      await expect(page.locator('a[href="/app/login/"]')).toHaveAttribute('href', '/app/login/');
    });

    test('Try Free button is present in nav', async ({ page }) => {
      await expect(page.locator('a[href="/about/signup/"]').first()).toBeVisible();
    });

    test('hero section is visible', async ({ page }) => {
      await expect(page.locator('#HomePage__HeroSection')).toBeVisible();
    });

    test('hero heading is present', async ({ page }) => {
      await expect(page.locator('#hero-section-heading')).toBeVisible();
    });

    test('hero heading contains expected text', async ({ page }) => {
      await expect(page.locator('#hero-section-heading')).toContainText('Trusted EHR');
    });

    test('Start My Free Trial CTA is visible', async ({ page }) => {
      await expect(page.locator('#HomePage__HeroSection a[href="/about/signup/"]')).toBeVisible();
    });

    test('Schedule a Demo CTA is visible', async ({ page }) => {
      await expect(page.locator('#HomePage__HeroSection a[href*="schedule"]')).toBeVisible();
    });

    test('Practice Management section is present', async ({ page }) => {
      await expect(page.locator('#HomePage__ClinicalSegments1')).toBeVisible();
    });

    test('Support section is present', async ({ page }) => {
      await expect(page.locator('#HomePage__SupportSection')).toBeVisible();
    });

    test('TherapyFuel AI section is present', async ({ page }) => {
      await expect(page.locator('#HomePage__TherapyFuelSection')).toBeVisible();
    });

    test('Mobile App section is present', async ({ page }) => {
      await expect(page.locator('#HomePage__MobileAppSection')).toBeVisible();
    });

    test('footer is present', async ({ page }) => {
      await expect(page.locator('.SiteFooter')).toBeVisible();
    });

    test('footer phone number is present', async ({ page }) => {
      await expect(page.locator('a[href="tel:+12156584550"]').first()).toBeVisible();
    });

  });

  test.afterEach(async ({ page }) => {
    await page.context().clearCookies();
  });

});
