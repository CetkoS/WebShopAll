import { Component, inject } from '@angular/core';
import { ProductsService } from './products.service';
import { Product } from './interfaces/product.interface';
import { CurrencyPipe } from '@angular/common';
import { ProductItemComponent } from "./product-item/product-item.component";
import { ProductFilterComponent } from "./product-filter/product-filter.component";

@Component({
  selector: 'app-products',
  imports: [ProductItemComponent, ProductFilterComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss',
})
export class ProductsComponent {
  productsService = inject(ProductsService);

  products: Product[] = [];

  constructor() {
    this.productsService.getProducts().subscribe((products) => {
      this.products = products;
    });
  }

  onCategorySelected(category: string | null) {
    if (category) {
      this.productsService.getProductsByCategory(category).subscribe((products) => {
        this.products = products;
      });
    } else {
      this.productsService.getProducts().subscribe((products) => {
        this.products = products;
      });
    }
  }
}
