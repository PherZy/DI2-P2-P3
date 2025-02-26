// src/app/components/add-password/add-password.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { Application } from '../../models/application';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-password',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  templateUrl: './add-password.component.html',
  styleUrls: ['./add-password.component.scss']
})
export class AddPasswordComponent implements OnInit {
  passwordForm: FormGroup;
  applications: Application[] = [];
  
  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
  ) {
    this.passwordForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      notes: [''],
      applicationId: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.loadApplications();
  }

  loadApplications(): void {
    this.apiService.getApplications().subscribe(
      (data) => {
        this.applications = data;
      },
      (error) => {
        console.error('Erreur lors du chargement des applications', error);
      }
    );
  }

  onSubmit(): void {
    if (this.passwordForm.valid) {
      this.apiService.addPassword(this.passwordForm.value).subscribe(
        () => {
          this.router.navigate(['/passwords']);
        },
        (error) => {
          console.error('Erreur lors de l\'ajout du mot de passe', error);
        }
      );
    } else {
      this.passwordForm.markAllAsTouched();
    }
  }
}