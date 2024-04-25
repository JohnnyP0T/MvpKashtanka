import { Component } from '@angular/core';
import {PetComponent} from "../pet/pet.component";
import {NgForOf} from "@angular/common";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-pets',
  standalone: true,
  imports: [
    PetComponent,
    NgForOf
  ],
  templateUrl: './pets.component.html',
  styleUrl: './pets.component.css'
})
export class PetsComponent {
  pets: any;

  constructor(
    private httpClient: HttpClient,
  ) { }
  ngOnInit() {
    this.getMockPets()
  }
  redirectToProductDetails(id: number) {

  }

  // Генерируем рандомных животных
  getMockPets() {
    this.httpClient.get( environment.apiUrl + '/api/Pet').subscribe((data: any) => {
      this.pets = data;
    });
    // this.pets = [
    //   {id: 1, name: 'Кот', description: 'Котик', price: 100},
    //
    // ]
  }
}
