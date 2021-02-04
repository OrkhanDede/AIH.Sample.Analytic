import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  return "https://aiherpanalyticapi20210204010407.azurewebsites.net/api/";
  if (environment.production) {
    return "https://aiherpanalyticapiapi.azure-api.net/api/";
  } else {
    return "https://localhost:44379/api/";
  }
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
