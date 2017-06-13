import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MdToolbarModule, MdButtonModule, MdInputModule, MdSelectModule, MdCardModule, MdCheckboxModule } from '@angular/material';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AgentsComponent } from './agents/agents.component';
import { PlayersComponent } from './players/players.component';
import { MarketsComponent } from './markets/markets.component';
import { ReportsComponent } from './reports/reports.component';
import { RulesComponent } from './rules/rules.component';

const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'agents', component: AgentsComponent },
  { path: 'players', component: PlayersComponent },
  { path: 'markets', component: MarketsComponent },
  { path: 'reports', component: ReportsComponent },
  { path: 'rules', component: RulesComponent },
  { path: '', redirectTo: '/agents', pathMatch: 'full' },
  { path: '**', redirectTo: '/agents', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AgentsComponent,
    PlayersComponent,
    MarketsComponent,
    ReportsComponent,
    RulesComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes),
    FlexLayoutModule,
    MdToolbarModule,
    MdButtonModule,
    MdInputModule,
    MdSelectModule,
    MdCardModule,
    MdCheckboxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
