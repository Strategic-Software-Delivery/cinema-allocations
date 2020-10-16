package com.sdd.cinemaallocationsacceptancetests;

import com.sdd.cinemaallocations.*;
import com.sdd.cinemaallocationsacceptancetests.helpers.StubMovieScreeningRepository;
import org.junit.Before;
import org.junit.Test;

import java.io.IOException;

import static com.google.common.truth.Truth.assertThat;

public class TicketBoothShould {

    private static final String FORD_THEATHER = "1";
    private static final String DOCK_STREET = "3";
    private static final String MADISON_THEATHER = "5";

    private TicketBooth ticketBooth;

    public TicketBoothShould() throws IOException {
        MovieScreeningRepository repository =  new StubMovieScreeningRepository();
        ticketBooth = new TicketBooth(repository);
    }

    @Test
    public void reserve_one_seat_when_available() {
        int partyRequested = 1;

        SeatsAllocated seatsAllocated = ticketBooth.allocateSeats(new AllocateSeats(FORD_THEATHER, partyRequested));

        assertThat(seatsAllocated.reservedSeats()).hasSize(1);
        assertThat(seatsAllocated.reservedSeats().get(0).toString()).isEqualTo("A3");
    }

    @Test
    public void return_SeatsNotAvailable_when_all_seats_are_unavailable() throws IOException {
        assertThat(true).isFalse();
    }

    @Test
    public void return_TooManyTicketsRequested_when_9_tickets_are_requested() throws IOException {
        assertThat(true).isFalse();
    }

}
