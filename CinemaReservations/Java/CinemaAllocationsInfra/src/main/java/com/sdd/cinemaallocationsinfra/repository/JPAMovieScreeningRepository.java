package com.sdd.cinemaallocationsinfra.repository;

import com.sdd.cinemaallocations.MovieScreening;
import com.sdd.cinemaallocations.MovieScreeningRepository;

public class JPAMovieScreeningRepository implements MovieScreeningRepository {

    private SpringMovieScreeningRepository springMovieScreeningRepository;

    public JPAMovieScreeningRepository(SpringMovieScreeningRepository springMovieScreeningRepository) {
        this.springMovieScreeningRepository = springMovieScreeningRepository;
    }

    @Override
    public MovieScreening findMovieScreeningById(String screeningId) {
        //TODO implement me
        return null;
    }

}
