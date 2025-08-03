import { Component } from '@angular/core';
import { ReservationService } from '../../services/reservation.service';
import { Observable, tap } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reservation-list',
  imports: [CommonModule],
  templateUrl: './reservation-list.component.html',
  styleUrl: './reservation-list.component.scss'
})
export class ReservationListComponent {
  constructor(private reservationService: ReservationService) {}

  public reservations$: Observable<any[]> = new Observable<any[]>();

  ngOnInit(): void {
    this.reservations$ = this.reservationService.getReservations().pipe(
      tap(reservations => console.log(reservations))
    );
  }
}