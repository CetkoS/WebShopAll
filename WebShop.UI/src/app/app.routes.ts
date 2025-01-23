import { Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./homepage/homepage.component').then(c => c.HomepageComponent) },
  { path: 'products', loadComponent: () => import('./products/products.component').then(c => c.ProductsComponent) },
];
