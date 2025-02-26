// src/app/components/application-list/application-list.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Application } from '../../models/application';

@Component({
  selector: 'app-application-list',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.scss']
})
export class ApplicationListComponent implements OnInit {
  applications: Application[] = [];
  applicationForm: FormGroup;
  
  constructor(
    private apiService: ApiService,
    private fb: FormBuilder
  ) {
    this.applicationForm = this.fb.group({
      name: ['', [Validators.required]],
      type: [1, [Validators.required]]
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
    if (this.applicationForm.valid) {
      this.apiService.addApplication(this.applicationForm.value).subscribe(
        (data) => {
          this.applications.push(data);
          this.applicationForm.reset({ type: 1 });
        },
        (error) => {
          console.error('Erreur lors de l\'ajout de l\'application', error);
        }
      );
    } else {
      this.applicationForm.markAllAsTouched();
    }
  }

  getApplicationTypeName(type: number): string {
    return type === 1 ? 'Grand public' : 'Professionnelle';
  }
}