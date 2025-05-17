export interface CreateBook {
    eventId: number;
    numberOfTickets: number;
};

export interface Status {
    id: number;
    name: string;
}

export interface BookingResponse {
    Id: number;
    eventId: number;
    userId: string;
    numberOfTickets: number;
    status: Status;
    createdAt: Date;
    updatedAt: Date;
}

export interface CreateEvent {
    name: string;
    description: string;
    date: Date;
    price: number;
    venue: string;
    availableTickets: number;
    statusId: number;
    tagsIds: number[];
}

export interface EventResponse {
    id: number;
    name: string;
    description: string;
    date: Date;
    price: number;
    venue: string;
    availableTickets: number;
    statusId: number;
    tagsIds: number[];
    createdAt: Date;
    updatedAt: Date;
    createdBy: string;
}

export interface UpdateEvent {
    name?: string;
    description?: string;
    date?: Date;
    price?: number;
    venue?: string;
    availableTickets?: number;
    statusId?: number;
}

export interface Tag {
    id: number;
    name: string;
}

export interface AddTagToEvent {
    tagId: number;
}

export interface EventTag {
    id: number;
    eventId: number;
    tagId: number;
}

export interface AppUser {
    id: string;
    role: string;
}