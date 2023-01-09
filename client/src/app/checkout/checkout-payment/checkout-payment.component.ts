import {
  AfterViewInit,
  Component,
  ElementRef,
  Input,
  ViewChild,
} from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { CardData } from 'src/app/shared/models/cardData';
import { IOrder } from 'src/app/shared/models/order';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss'],
})
export class CheckoutPaymentComponent implements AfterViewInit {
  @Input() checkoutForm: FormGroup;
  cardData: CardData;

  constructor(
    private basketService: BasketService,
    private checkoutService: CheckoutService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngAfterViewInit() {}

  ngOnDestroy() {
    this.cardData = null;
  }

  submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();
    const orderToCreate = this.getOrderToCreate(basket);

    this.checkoutService.createOrder(orderToCreate).subscribe(
      (order: IOrder) => {
        this.basketService.deleteBasket(basket);
        const navigationExtras: NavigationExtras = { state: order };
        this.router.navigate(['checkout/success']), navigationExtras;
      },
      (error) => {
        this.toastr.error(error);
        console.log(error);
      }
    );
  }

  createPaymnetIntent() {
    this.setCardData();

    return this.basketService.createPaymentIntent(this.cardData).subscribe(
      (response: any) => {
        if (response.status === 'success') {
          this.toastr.success('Payment intent and Order created');
          this.submitOrder();
        }else{
          this.toastr.error(`Payment ${response.status}`);
        }
      },
      (error) => {
        console.log(error);
        this.toastr.error(error.message);
      }
    );
  }

  private getOrderToCreate(basket: IBasket) {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm
        .get('deliveryForm')
        .get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('addressForm').value,
    };
  }

  setCardData() {
    var formRes = this.checkoutForm.get('paymentForm').value;
    this.cardData = new CardData();
    this.cardData.card = formRes.card.replace(/\s+/g, '');
    this.cardData.cardCvv = formRes.cvv.replace(/\s+/g, '');
    this.cardData.cardExpMonth = formRes.expiration
      .split('/')[0]
      .replace(/\s+/g, '');
    this.cardData.cardExpYear = formRes.expiration
      .split('/')[1]
      .replace(/\s+/g, '');
  }
}
function ViewChield() {
  throw new Error('Function not implemented.');
}
