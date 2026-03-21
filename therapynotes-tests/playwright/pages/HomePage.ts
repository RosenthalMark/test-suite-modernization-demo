import { Page, Locator, expect } from '@playwright/test';

export class HomePage {
  readonly page: Page;

  // Post-login dashboard elements
  readonly welcomeHeader: Locator;
  readonly dashboardContainer: Locator;

  constructor(page: Page) {
    this.page = page;

    // Primary assertion target — welcome message
    // Matches "Welcome, Test User" or any welcome heading
    this.welcomeHeader = page.getByRole('heading', { name: /welcome/i }).or(
      page.locator('h1, h2').filter({ hasText: /welcome/i })
    );

    // Fallback — if the dashboard loads but welcome text is elsewhere
    this.dashboardContainer = page.locator(
      '[class*="dashboard"], [id*="dashboard"], main, [role="main"]'
    ).first();
  }

  // Assert that login was successful by checking for welcome message
  // Mirrors the Selenium assertion: Assert.Contains("Welcome, Test User", welcomeHeader.Text)
  async assertWelcomeMessage(expectedName?: string) {

    // Wait for navigation away from login page to complete
    await this.page.waitForURL((url) => !url.toString().includes('login'), {
      timeout: 10000,
    });

    // Assert welcome heading is visible
    await expect(this.welcomeHeader).toBeVisible({ timeout: 10000 });

    // If a specific name is provided, assert it appears in the heading
    if (expectedName) {
      await expect(this.welcomeHeader).toContainText(expectedName);
    }
  }

  // Assert the full dashboard has loaded (useful as a secondary check)
  async assertDashboardLoaded() {
    await expect(this.dashboardContainer).toBeVisible({ timeout: 10000 });
  }
}
