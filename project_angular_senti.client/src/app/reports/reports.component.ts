import { Component } from '@angular/core';

@Component({
  selector: 'app-reports',
  standalone: false,
  templateUrl: './reports.component.html',
  styleUrl: './reports.component.css'
})
export class ReportsComponent {
  widgets = [
    { id: 0, title: 'Something FS' },
  ];

  nextId = 1

  addWidget() {
    const newWidget = { id: this.nextId++, title: 'New Widget'};
    this.widgets.push(newWidget);
  };

  deleteWidget(widgetId: number) {
    this.widgets = this.widgets.filter(widget => widget.id !== widgetId);
  }
}
