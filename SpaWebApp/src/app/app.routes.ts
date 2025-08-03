import { Routes } from '@angular/router';
import { HomeScreenComponent } from './components/home-screen/home-screen.component';
import { ReservationFormComponent } from './components/reservation-form/reservation-form.component';
import { ReservationListComponent } from './components/reservation-list/reservation-list.component';

export const routes: Routes = [
  { path: '', component: HomeScreenComponent },
  { path: 'reservation/create', component: ReservationFormComponent },
  { path: 'reservation/list', component: ReservationListComponent },
];
