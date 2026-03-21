typescriptimport { Page, Locator } from '@playwright/test';

export class LoginPage {
  readonly page: Page;

  readonly practiceCodeField: Locator;
  readonly practiceCodeContinueButton: Locator;
  readonly usernameField: Locator;
  readonly passwordField: Locator;
  readonly loginButton: Locator;
  readonly loginLink: Locator;

  constructor(page: Page) {
    this.page = page;

    this.practiceCodeField = page.getByLabel('Practice Code').or(
      page.locator('input[name="practice_code"], input[id*="practice"], input[placeholder*="practice" i]')
    );
    this.practiceCodeContinueButton = page.getByRole('button', { name: /continue|next/i });

    this.usernameField = page.getByLabel('Username').or(
      page.locator('input[name="username"], input[id*="username"], input[type="text"]').first()
    );
    this.passwordField = page.getByLabel('Password').or(
      page.locator('input[name="password"], input[id*="password"], input[type="password"]')
    );
    this.loginButton = page.getByRole('button', { name: /log in|login|sign in/i });
    this.loginLink = page.getByRole('link', { name: /log in|login/i });
  }

  async navigate() {
    await this.page.goto('/');
  }

  async clickLoginLink() {
    await this.loginLink.click();
    await this.page.waitForURL(/login/i);
  }

  async login(practiceCode: string, username: string, password: string) {
    await this.practiceCodeField.waitFor({ state: 'visible' });
    await this.practiceCodeField.fill(practiceCode);
    await this.practiceCodeContinueButton.click();

    await this.usernameField.waitFor({ state: 'visible' });
    await this.usernameField.fill(username);
    await this.passwordField.fill(password);
    await this.loginButton.click();
  }
}
