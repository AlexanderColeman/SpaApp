import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Reservation {
  id: number;
  customerName: string;
  date: string;
  time: string;
  numberOfGuests: number;
}

@Injectable({
  providedIn: 'root',
})
export class ReservationService {
  private readonly apiUrl = 'https://localhost:8081/Reservation';
  private http = inject(HttpClient);

  getAll(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.apiUrl);
  }

  getById<T>(id: number): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}/${id}`);
  }

  create<T>(reservation: T): Observable<T> {
    return this.http.post<T>(this.apiUrl, reservation);
  }

  update<T>(id: number, reservation: T): Observable<T> {
    return this.http.put<T>(`${this.apiUrl}/${id}`, reservation);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
