import {Component} from '@angular/core';

import {FuseTranslationLoaderService} from '@fuse/services/translation-loader.service';
declare var $, kendo:any;

@Component({
    selector: 'sample',
    templateUrl: './sample.component.html',
    styleUrls: ['./sample.component.scss']
})
export class SampleComponent {
    /**
     * Constructor
     *
     * @param {FuseTranslationLoaderService} _fuseTranslationLoaderService
     */
    constructor() {
        $(function() {
            $("#scheduler").kendoScheduler({
                date: new Date(),
                startTime: new Date("2013/6/13 07:00 AM"),
                height: 600,
                views: [
                    "day",
                    { type: "week", selected: true },
                    "month",
                    "timeline"
                ],
                timezone: "Etc/UTC",
                dataSource: {
                    batch: true,
                    transport: {
                        read: {
                            url: "https://demos.telerik.com/kendo-ui/service/meetings",
                            dataType: "jsonp"
                        },
                        update: {
                            url: "https://demos.telerik.com/kendo-ui/service/meetings/update",
                            dataType: "jsonp"
                        },
                        create: {
                            url: "https://demos.telerik.com/kendo-ui/service/meetings/create",
                            dataType: "jsonp"
                        },
                        destroy: {
                            url: "https://demos.telerik.com/kendo-ui/service/meetings/destroy",
                            dataType: "jsonp"
                        },
                        parameterMap: function(options, operation) {
                            if (operation !== "read" && options.models) {
                                return {models: kendo.stringify(options.models)};
                            }
                        }
                    },
                    schema: {
                        model: {
                            id: "meetingID",
                            fields: {
                                meetingID: { from: "MeetingID", type: "number" },
                                title: { from: "Title", defaultValue: "No title", validation: { required: true } },
                                start: { type: "date", from: "Start" },
                                end: { type: "date", from: "End" },
                                startTimezone: { from: "StartTimezone" },
                                endTimezone: { from: "EndTimezone" },
                                description: { from: "Description" },
                                recurrenceId: { from: "RecurrenceID" },
                                recurrenceRule: { from: "RecurrenceRule" },
                                recurrenceException: { from: "RecurrenceException" },
                                roomId: { from: "RoomID", nullable: true },
                                attendees: { from: "Attendees", nullable: true },
                                isAllDay: { type: "boolean", from: "IsAllDay" }
                            }
                        }
                    }
                },
                group: {
                    resources: ["Rooms"]
                },
                resources: [
                    {
                        field: "roomId",
                        name: "Rooms",
                        dataSource: [
                            { text: "Tech1", value: 1, color: "#6eb3fa" },
                            { text: "Tech1", value: 2, color: "#f58a8a" },
                            { text: "Tech1", value: 3, color: "#6eb3fa" },
                            { text: "Tech1", value: 4, color: "#f58a8a" },
                            { text: "Tech1", value: 5, color: "#6eb3fa" },
                            { text: "Tech1", value: 6, color: "#f58a8a" },
                            { text: "Tech1", value: 7, color: "#6eb3fa" },
                            { text: "Tech1", value: 8, color: "#f58a8a" },
                        ],
                        title: "Room"
                    },
                    {
                        field: "attendees",
                        name: "Attendees",
                        dataSource: [
                            { text: "pedi", value: 1, color: "#f8a398" },
                            { text: "mani", value: 2, color: "#51a0ed" },
                            { text: "full set", value: 3, color: "#56ca85" }
                        ],
                        multiple: true,
                        title: "Attendees"
                    }
                ]
            });
        });
    }
}
