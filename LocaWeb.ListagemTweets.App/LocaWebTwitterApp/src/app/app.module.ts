

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';

import { InjectionToken } from '@angular/core';
import { MostMentionsComponent } from './most-mentions/most-mentions.component';
import { MostRelevantsComponent } from './most-relevants/most-relevants.component';
export const BASE_URL = new InjectionToken<string>('BASE_URL');

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    MostMentionsComponent,
    MostRelevantsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'relevantes', component: MostRelevantsComponent },
      { path: 'mentions', component: MostMentionsComponent },
    ])
  ],
  providers: [{ provide: BASE_URL , useValue: 'http://localhost:5000/' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
