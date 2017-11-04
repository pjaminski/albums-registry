import { RouterConfiguration } from 'aurelia-router';

export class App {
  configureRouter(config: RouterConfiguration)
  {
    config.title = "Albums Registry";

    config.map([
      { route: ['', 'albums'], name: 'albums', moduleId: './albums/view-models/albums', nav: true, title: 'Albums' }
    ])
  }
}
