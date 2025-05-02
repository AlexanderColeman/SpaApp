import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ReservationService } from '../../services/reservation.service';

@Component({
  selector: 'reservation-form',
  imports: [ReactiveFormsModule],
  templateUrl: './reservation-form.component.html',
  styleUrl: './reservation-form.component.scss'
})
export class ReservationFormComponent {
  constructor(
    private fb: FormBuilder,
    private reservationService: ReservationService
  ) {}

  reservationForm!: FormGroup;

  ngOnInit(): void {
    this.initForm();
  }
  initForm(): void {
    this.reservationForm = this.fb.group({
      customerName: ['', [Validators.required, Validators.minLength(3)]],
      createdDate: ['', Validators.required],
      numberOfGuests: ['', [Validators.required, Validators.min(1)]],
    });
  }
  
  onSubmit(): void {
    if (this.reservationForm.invalid) {
      console.log('Reservation Details:', this.reservationForm.value);
    } 

    this.reservationService.saveUpdateReservation(this.reservationForm.value).subscribe({
      next: (response) => {
        console.log('Reservation created successfully:', response);
        this.reservationForm.reset();
      }
    })
  }
}
