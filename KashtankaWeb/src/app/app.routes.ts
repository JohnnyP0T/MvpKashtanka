import { Routes } from '@angular/router';
import {PetsComponent} from "./components/pets/pets.component";
import {PetComponent} from "./components/pet/pet.component";
import {MainPageComponent} from "./components/main-page/main-page.component";

export const routes: Routes = [
  {path: 'pets', component: PetsComponent},
  {path: 'pet/:id', component: PetComponent},
  {path: '', component: MainPageComponent}
];
