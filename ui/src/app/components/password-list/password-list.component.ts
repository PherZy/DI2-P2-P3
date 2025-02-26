import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Password } from '../../models/password';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-password-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './password-list.component.html',
  styleUrls: ['./password-list.component.scss']
})
export class PasswordListComponent implements OnInit {
  passwords: Password[] = [];
  visiblePasswordIds: Set<number> = new Set(); // Pour suivre les mots de passe visibles
  
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadPasswords();
  }

  loadPasswords(): void {
    this.apiService.getPasswords().subscribe(
      (data) => {
        this.passwords = data;
      },
      (error) => {
        console.error('Erreur lors du chargement des mots de passe', error);
      }
    );
  }

  deletePassword(id: number): void {
    if (confirm('Êtes-vous sûr de vouloir supprimer ce mot de passe ?')) {
      this.apiService.deletePassword(id).subscribe(
        () => {
          this.passwords = this.passwords.filter(p => p.id !== id);
          this.visiblePasswordIds.delete(id); // Nettoyer l'ensemble des IDs
        },
        (error) => {
          console.error('Erreur lors de la suppression du mot de passe', error);
        }
      );
    }
  }

  // Fonction pour basculer la visibilité d'un mot de passe
  togglePasswordVisibility(id: number): void {
    if (this.visiblePasswordIds.has(id)) {
      this.visiblePasswordIds.delete(id);
    } else {
      this.visiblePasswordIds.add(id);
    }
  }

  // Fonction pour vérifier si un mot de passe est visible
  isPasswordVisible(id: number): boolean {
    return this.visiblePasswordIds.has(id);
  }
}