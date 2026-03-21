# TherapyNotes Test Suite
### Selenium/C# vs Playwright/TypeScript — Side by Side
 
This repo contains two implementations of the same E2E login
test for TherapyNotes. Same coverage. Same assertions. Two
very different stacks.
 
## Structure
 
```
therapynotes-tests/
├── playwright/          # Modern — Playwright + TypeScript
│   ├── playwright.config.ts
│   ├── tests/Login.spec.ts
│   └── pages/LoginPage.ts, HomePage.ts
└── selenium/            # Legacy — Selenium + C# + xUnit
    ├── Tests/LoginTests.cs
    └── Pages/LoginPage.cs, HomePage.cs
```
 
## Running Playwright
 
```bash
cd playwright
npm install
npx playwright install chromium
npm run test:ui
```
 
## Running Selenium
 
```bash
cd selenium
dotnet restore
dotnet test
```
 
## Why Two Versions?
 
TherapyNotes' frontend is React + Next.js + TypeScript.
Playwright was built for exactly that stack. This repo shows
the same test written both ways — same logic, same assertions,
same POM structure. The only difference is how much code it
takes to express the same idea, and what you get for free
(auto-waiting, screenshots, video, trace, mobile emulation).
 
Built by Mark Rosenthal — markrosenthal.site
