package com.sdd.cinemaallocationsinfra.repository;

import com.sdd.cinemaallocations.MovieScreening;
import com.sdd.cinemaallocations.MovieScreeningRepository;
import com.sdd.cinemaallocationsinfra.repository.model.JPAMovieScreening;

import java.util.Optional;

public class JPAMovieScreeningRepository implements MovieScreeningRepository {

    private SpringMovieScreeningRepository springMovieScreeningRepository;

    public JPAMovieScreeningRepository(SpringMovieScreeningRepository springMovieScreeningRepository) {
        this.springMovieScreeningRepository = springMovieScreeningRepository;
    }

    @Override
    public MovieScreening findMovieScreeningById(String screeningId)  {
        Optional<JPAMovieScreening> jpaMovieScreening = springMovieScreeningRepository.findById(screeningId);
        return jpaMovieScreening.map(this::fromJPAMovieScreening).orElse(null);
    }

    private MovieScreening fromJPAMovieScreening(JPAMovieScreening jpaMovieScreening) {
        //TODO Implement me
        return null;
    }

}
