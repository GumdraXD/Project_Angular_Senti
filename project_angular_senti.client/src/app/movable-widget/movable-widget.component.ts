import { Component, HostListener, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-movable-widget',
  standalone: false,
  templateUrl: './movable-widget.component.html',
  styleUrls: ['./movable-widget.component.css'],
})
export class MovableWidgetComponent {
  posX = 100;  // Initial X position   
  posY = 100;  // Initial Y position
  isDragging = false;

  @Input() id!: number;
  @Input() title: string = '';  
  @Input() content: string = '';
  @Input() imageUrl: string = '';
  @ViewChild('titleInput') titleInput!: ElementRef; //allows access to ODM element and keeps a reference to it

  isEditing = false;

  @Output() remove: EventEmitter<number> = new EventEmitter<number>() //allows complete and easy removal of components 

  // Mouse position at the start of dragging
  private mouseX = 0;
  private mouseY = 0;

  startDrag(event: MouseEvent) { //activates when the mouse button is pressed
    this.isDragging = true;
    this.mouseX = event.clientX;
    this.mouseY = event.clientY;

    event.preventDefault();
  }

  @HostListener('document:mousemove', ['$event'])
  onMouseMove(event: MouseEvent) {  //specfically looks for element with the event tag
    if (this.isDragging) {
      const dx = event.clientX - this.mouseX;
      const dy = event.clientY - this.mouseY;

      this.posX += dx;
      this.posY += dy;

      this.mouseX = event.clientX;
      this.mouseY = event.clientY;
    }
  }

  @HostListener('document:mouseup')
  onMouseUp() {   //triggers when the mouse is unpressed
    this.isDragging = false;
  }

  deleteWidget() {
    this.remove.emit(this.id);    //uses event emitter and deletes at the spcific id
  }

  enableEditing() {
    this.isEditing = true;

    setTimeout(() => {
      this.titleInput.nativeElement.focus();
    });
  }

  disableEditing() {
    this.isEditing = false;
  }

}
