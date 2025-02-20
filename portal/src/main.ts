import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import {LicenseManager} from 'ag-grid-enterprise';

LicenseManager.setLicenseKey('DownloadDevTools_COM_NDEwMjM0NTgwMDAwMA==59158b5225400879a12a96634544f5b6');


bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
