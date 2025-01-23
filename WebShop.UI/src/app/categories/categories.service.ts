import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { inject, Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  http = inject(HttpClient);

  getCategories() {
    return this.http.get<string[]>(`${environment.apiUrl}/Categories`);
  }
}
