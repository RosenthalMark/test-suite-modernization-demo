# TherapyNotes Test Suite
### Playwright/TypeScript vs Selenium/C# — Side by Side

This repo was built in one night after receiving a rejection email.
The assessment asked for Selenium/C#. I built that, then built the
modern equivalent alongside it so you could see the difference.

Same coverage. Same assertions. Same site. Two very different stacks.

---

## Structure
```
TherapyNotes-tests/
├── playwright/                    # Modern stack
│   ├── playwright.config.ts
│   ├── package.json
│   ├── pages/
│   │   ├── LoginPage.ts           # Page Object — selectors + actions
│   │   └── HomePage.ts            # Page Object — post-login assertions
│   └── tests/
│       ├── homepage.smoke.spec.ts # 22 homepage smoke tests
│       └── login.spec.ts          # 16 login flow tests
│
└── selenium/                      # Legacy stack
    └── Tests/
        ├── HomepageSmokeTests.cs  # 20 homepage smoke tests
        └── LoginPageSmokeTests.cs # 15 login flow tests
```

---

## The Numbers

| | Playwright | Selenium |
|---|---|---|
| Tests | 114 (across 3 browsers) | 35 (Chrome only) |
| Browsers | Chrome, Firefox, Safari | Chrome |
| Run time | ~1m 48s | ~60s |
| Setup steps | 2 | 4 |
| Built-in video | Yes | No |
| Built-in trace | Yes | No |
| Built-in screenshots | Yes | No |
| HTML report | Yes | No |
| Mobile viewports | Architected (Pixel 7, iPhone 14) | No |

---

## Running Playwright
```bash
cd playwright
npm install
npx playwright install chromium firefox webkit
npm run test:ui          # Visual debugger — recommended first run
npm run test             # Headless, all browsers
npm run test:record      # Full video, screenshots, traces on every test
npm run test:fast        # Chromium only, fastest feedback
npm run test:pr-gate     # PR gate mode, GitHub Actions reporter
npm run test:report      # Open HTML report after a run
```

### Environment Variables
```bash
# Default — fast, records only on failure
npm run test

# Full recording mode — video, screenshots, traces on every test
RECORD=true npm run test
```

---

## Running Selenium

Requirements: .NET 10 SDK, Chrome browser
```bash
cd selenium
dotnet restore
dotnet test
```

---

## Why Playwright for TherapyNotes?

TherapyNotes runs React, Next.js, and TypeScript on the frontend.
Playwright was built specifically for that stack. That wasn't a
random choice — I looked up your tech stack before picking the tool.

The Selenium suite requires installing .NET SDK, matching ChromeDriver
to your exact Chrome version, and restoring NuGet packages before a
single test runs. Playwright is npm install and go. On a team of
engineers, that setup friction compounds fast.

---

## The Bigger Picture

This repo is a small demonstration of something I'm building called
the Rosetta Stone, part of GhostOps Terminal. The concept: instead
of manually rewriting legacy test suites, automate the translation.
Read the existing test logic, understand the intent, output clean
modern equivalents without losing the business logic your QA team
spent years building.

This repo shows the translation is 1:1. The test logic maps directly.
The only thing that changes is how much code it takes to express the
same idea, and what you get for free on the other side.

---

Built by Mark Rosenthal — [markrosenthal.site](https://markrosenthal.site)

