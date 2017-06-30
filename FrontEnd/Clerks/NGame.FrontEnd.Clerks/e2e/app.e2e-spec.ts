import { NGame.FrontEnd.ClerksPage } from './app.po';

describe('ngame.front-end.clerks App', () => {
  let page: NGame.FrontEnd.ClerksPage;

  beforeEach(() => {
    page = new NGame.FrontEnd.ClerksPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
