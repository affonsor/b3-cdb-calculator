import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})

export class App {
  investmentRequest = { initialValue: 0, months: 0 };
  investmentResponse: any;
  errorMessage: string | null = null;
  successMessage: string | null = null;

  constructor(private http: HttpClient) { }

  calculateInvestment() {
    const url = 'https://localhost:7005/api/Cdb/calculate'; // Sua URL do backend

    this.http.post<any>(url, this.investmentRequest).subscribe({
      next: (response) => {
        this.investmentResponse = response.data;
        this.successMessage = response.message;
        this.errorMessage = null;
      },
      error: (err) => {
        console.error(err);
        if (err.error && err.error.message) {
          this.errorMessage = err.error.message;
        } else {
          this.errorMessage = "An unexpected error occurred.";
        }
        this.successMessage = null;
        this.investmentResponse = null;
      },
    });
  }
}
