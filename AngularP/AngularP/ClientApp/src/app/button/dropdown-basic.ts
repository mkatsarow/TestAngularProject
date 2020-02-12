import { Component } from '@angular/core';

@Component({
  selector: 'ngbd-dropdown-basic',
  templateUrl: './dropdown-basic.html'
})

export class NgbdDropdownBasic {
  displayMessage = "Sort by...";
  sortOptions = ["Balance", "Company", "Last Name"]

  changeMessage(selectedItem: string) {
    this.displayMessage = "Sort by " + selectedItem;
  }
}
