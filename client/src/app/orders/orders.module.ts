import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { OrdersComponent } from './orders.component';
import { RouterModule, Routes } from '@angular/router';
import { OrderPendingComponent } from './order-pending/order-pending.component';

const routes: Routes = [
  { path: '', component: OrdersComponent },
  {
    path: ':id',
    component: OrderPendingComponent,
    data: { breadcrumb: { alias: 'OrderPending' } },
  },
];

@NgModule({
  declarations: [OrderPendingComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrdersModule {}
