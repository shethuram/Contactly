import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Contact } from '../models/contact.model';
import { Observable } from 'rxjs/internal/Observable';
import { AsyncPipe } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet , HttpClientModule , AsyncPipe , FormsModule , ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  title = 'Contactly.web';

  http = inject(HttpClient);

  contacts$ = this.getContacts(); // variable for accessing contacts observable

  contactsForm = new FormGroup({
    name: new FormControl<string>(''),
    email: new FormControl<string>(''),
    phone: new FormControl<string>(''),
    favorite: new FormControl<boolean>(false)
  });
  

onFormSubmit(){
  const addContactRequest = {
    name: this.contactsForm.value.name,
    email: this.contactsForm.value.email,
    phone: this.contactsForm.value.phone,
    favorite: this.contactsForm.value.favorite
  }

  this.http.post('https://localhost:7011/api/Contacts', addContactRequest).subscribe(() => {
    this.contacts$ = this.getContacts();  // each time on  submission , you again need to get that here to display
    this.contactsForm.reset();
  });
}


onDelete(id: string){
  this.http.delete(`https://localhost:7011/api/Contacts/${id}`)
  .subscribe({
    next: (value) => {
      alert('item deleted successfully')
      this.contacts$ = this.getContacts();  // after deleting , you need to get all contacts again
    }
  })


}

  
private getContacts(): Observable<Contact[]>{
  
  return this.http.get<Contact[]>('https://localhost:7011/api/Contacts');
}





  
}


