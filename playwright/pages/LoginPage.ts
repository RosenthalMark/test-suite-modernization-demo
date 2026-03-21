import { Page, Locator } from '@playwright/test';

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

    this.practiceCodeField = page.locator('#PracticeCode');
    this.practiceCodeContinueButton = page.locator('#Continue__ContinueButton');

    this.usernameField = page.locator('#Login__UsernameField');
    this.passwordField = page.locator('#Login__Password');
    this.loginButton = page.locator('#Login__LogInButton');
    this.loginLink = page.locator('a[href="/app/login/"]');
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
