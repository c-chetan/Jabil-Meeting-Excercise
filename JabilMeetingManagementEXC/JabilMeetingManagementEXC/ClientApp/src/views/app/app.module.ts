import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

//Import Modules
import { AppRoutingModule } from './app-routing.module';
import { LoginModule } from '../login/login.module';

//Import Components
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
