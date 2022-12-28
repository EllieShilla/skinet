import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { ErrorInterseptor } from './core/interseptors/error.interseptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterseptor } from './core/interseptors/loading.interseptors';
import { JwtInterceptor } from './core/interseptors/jwt.interceptor';
import { OrdersComponent } from './orders/orders.component';
import { OrdersModule } from './orders/orders.module';

@NgModule({
  declarations: [AppComponent, OrdersComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    NgxSpinnerModule,
    OrdersModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterseptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterseptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
