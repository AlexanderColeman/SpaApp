import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { ReservationService } from './services/reservation.service';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';

@Component({
  selector: 'app-root',
  imports: [CommonModule, RouterOutlet, NavBarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: true,
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
