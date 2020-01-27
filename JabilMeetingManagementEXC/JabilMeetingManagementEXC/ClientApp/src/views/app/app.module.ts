import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

//Import Modules
import { AppRoutingModule } from './app-routing.module';
import { LoginModule } from '../login/login.module';
import { HttpClientModule } from '@angular/common/http';

//Import Components
import { AppComponent } from './app.component';
import { importType } from '@angular/compiler/src/output/output_ast';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    LoginModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
