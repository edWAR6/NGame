import { browser, element, by } from 'protractor';

export class NGame.FrontEnd.AgentsPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('app-root h1')).getText();
  }
}
