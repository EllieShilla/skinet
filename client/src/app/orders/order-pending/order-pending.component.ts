import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketTotals } from 'src/app/shared/models/basket';
import { IOrder } from 'src/app/shared/models/order';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-pending',
  templateUrl: './order-pending.component.html',
  styleUrls: ['./order-pending.component.scss'],
})
export class OrderPendingComponent implements OnInit {
  order: IOrder;
  basketTotal$: Observable<IBasketTotals>;

  constructor(
    private router: Router,
    private basketService: BasketService,
    private breadcrumbService: BreadcrumbService
  ) {
    this.breadcrumbService.set('@OrderPending', '11');

    const navigation = this.router.getCurrentNavigation();
    const state = this.router.getCurrentNavigation().extras.state.orderData;
    if (state) {
      this.order = state as IOrder;
      this.breadcrumbService.set(
        '@OrderPending',
        `Order# ${this.order.id} - ${this.order.status}`
      );
    }
  }

  ngOnInit() {
    this.basketTotal$ = this.basketService.basketTotal$;
  }
}
