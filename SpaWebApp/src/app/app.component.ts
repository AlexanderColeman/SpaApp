import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ReservationService } from './services/reservation.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'SpaWebApp';

  constructor(private reservationService: ReservationService) {}

  getReservation() {
    this.reservationService.getAll().subscribe((reservation: any) => {
      console.log('Reservation with ID 1:', reservation);
    });
  }
}
