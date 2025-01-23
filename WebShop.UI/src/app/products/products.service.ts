import { inject, Injectable } from '@angular/core';
import { Product } from './interfaces/product.interface';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  http = inject(HttpClient);

  getProducts() {
    return this.http.get<Product[]>(`${environment.apiUrl}/products`);
  }

  getProduct(id: number) {
    return this.http.get<Product>(`${environment.apiUrl}/products/${id}`);
  }

  getProductsByCategory(category: string) {
    return this.http.get<Product[]>(`${environment.apiUrl}/products/category/${category}`);
  }
}
