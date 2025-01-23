import { Component, Input } from '@angular/core';
import { Product } from '../interfaces/product.interface';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-product-item',
  imports: [CurrencyPipe],
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss',
})
export class ProductItemComponent {
  @Input() product!: Product;
}
