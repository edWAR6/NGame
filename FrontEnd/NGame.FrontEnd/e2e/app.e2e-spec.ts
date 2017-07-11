import { NGame.FrontEnd.AgentsPage } from './app.po';

describe('ngame.front-end.agents App', () => {
  let page: NGame.FrontEnd.AgentsPage;

  beforeEach(() => {
    page = new NGame.FrontEnd.AgentsPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
